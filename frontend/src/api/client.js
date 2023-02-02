import axios from 'axios'

const instance = axios.create({
  headers: {
    // api-key if need
    'x-api-key': ''
  },
  // TODO: add url
  baseURL: ''
})

const getProducts = async function () {
  return await instance.get('/products')
    .then(response => response.data)
}

const getReceipts = async function () {
  return await instance.get('/receipts')
    .then(response => response.data)
}

export { getProducts, getReceipts }
export default instance()
