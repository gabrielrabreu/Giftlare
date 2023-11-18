import axios, { AxiosInstance } from "axios";

class ApiService {
  protected api: AxiosInstance;

  constructor() {
    this.api = axios.create({
      baseURL: process.env.REACT_APP_API_URL,
    });

    const addTokenToHeaders = () => {
      const token = localStorage.getItem("token");
      if (token) {
        this.api.defaults.headers.common["Authorization"] = `Bearer ${token}`;
      } else {
        delete this.api.defaults.headers.common["Authorization"];
      }
    };

    this.api.interceptors.request.use(
      (config) => {
        addTokenToHeaders();
        return config;
      },
      (error) => {
        return Promise.reject(error);
      },
    );
  }
}

export default ApiService;
