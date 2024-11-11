<template>
  <v-app dark>
    <v-container>
      <v-row>
        <v-col cols="12" md="6">
          <v-text-field label="Router IP" v-model="routerIp" outlined dense />
          <v-text-field label="Username" v-model="username" outlined dense />
          <v-text-field label="Password" v-model="password" type="password" outlined dense />
          <v-btn @click="connectRouter" color="primary">Connect</v-btn>
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <v-checkbox
            v-for="(band, index) in availableBands"
            :key="index"
            :label="band"
            v-model="bandSelections[band]"
          />
          <v-btn @click="changeBands" color="secondary" :disabled="!connected">Change Bands</v-btn>
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <p>Current Bands: {{ currentBands.join(', ') || 'None' }}</p>
          <p>Status: {{ statusMessage }}</p>
        </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>

<script>
import { invoke } from '@tauri-apps/api';

export default {
  data() {
    return {
      routerIp: "192.168.1.1",
      username: "administrator",
      password: "",
      connected: false,
      availableBands: ["EUTRAN_BAND1", "EUTRAN_BAND3", "EUTRAN_BAND5", "EUTRAN_BAND38", "EUTRAN_BAND41"],
      bandSelections: {},
      currentBands: [],
      statusMessage: ""
    };
  },
  methods: {
    async connectRouter() {
      try {
        const result = await invoke("connect_router", { routerIp: this.routerIp, username: this.username, password: this.password });
        this.connected = result.success;
        this.statusMessage = result.message;
        if (this.connected) this.fetchCurrentBands();
      } catch (error) {
        this.statusMessage = "Failed to connect to router";
      }
    },
    async changeBands() {
      const selectedBands = Object.keys(this.bandSelections).filter(band => this.bandSelections[band]);
      const result = await invoke("change_lte_bands", { bands: selectedBands });
      this.statusMessage = result.message;
      if (result.success) this.fetchCurrentBands();
    },
    async fetchCurrentBands() {
      const result = await invoke("get_current_bands");
      this.currentBands = result.bands || [];
    }
  }
};
</script>

<style scoped>
/* Add any custom styling for dark mode here */
</style>
