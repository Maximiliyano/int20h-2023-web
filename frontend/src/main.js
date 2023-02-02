import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from '@/router'
import { Auth0Plugin } from '@/auth'
import authConfig from '../auth_config.json'
import JsonTreeViewer from 'vue-json-tree-viewer'

Vue.config.productionTip = false

// ToDo: Change authconfig from PIS SUP to LUI when Auth0 page will be done
Vue.use(Auth0Plugin, {
  domain: authConfig.domain,
  clientId: authConfig.clientId,
  onRedirectCallback: appState => {
    router.push(
      appState && appState.targetUrl
        ? appState.targetUrl
        : window.location.pathname
    )
  }
})

Vue.use(JsonTreeViewer)

new Vue({
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app')
