import { createApp } from 'vue';
import App from './App.vue';
import vuetify from './plugins/vuetify'; // Configure Vuetify here
import { createVuetify } from 'vuetify';

createApp(App).use(createVuetify()).mount('#app');
