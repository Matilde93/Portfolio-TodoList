const baseUri = "https://todolist20240827205147.azurewebsites.net/api/items";

Vue.createApp({
  data() {
    return {
      id: "",
      name: "",
      description: "",
      items: [],
      error: "",
    };
  },
  async created() {
    console.log("created method called");
    this.GetAll();
  },
  methods: {
    async GetAll() {
      try {
        const response = await axios.get(baseUri);
        this.items = await response.data;
        this.error = null;
      } catch (e) {
        this.items = [];
        this.error = e.message;
      }
    },
    async SaveItem(name, description) {
      id = 0;
      const newItem = { id: id, name: name, description: description };
      try {
        response = await axios.post(baseUri, newItem);
        this.items = await response.data;
        this.GetAll();
        this.name = "";
        this.quantity = "";
      } catch (ex) {
        alert(ex.message);
      }
    },
    async DeleteItem(id) {
      try {
        response = await axios.delete(baseUri + "/" + id);
        this.items = await response.data;
        this.GetAll();
      } catch (ex) {
        alert(ex.message);
      }
    },
  },
}).mount("#app");
