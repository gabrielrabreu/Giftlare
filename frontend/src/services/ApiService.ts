import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from "axios";

import { translate } from "../translate";

class ApiService {
  protected api: AxiosInstance;

  constructor() {
    this.api = axios.create({
      baseURL: process.env.REACT_APP_API_URL,
    });

    this.setupInterceptors();
  }

  private async addLanguageToHeaders() {
    try {
      const language = localStorage.getItem("language");
      if (language) {
        this.api.defaults.headers.common["Language"] = language;
      } else {
        delete this.api.defaults.headers.common["Language"];
      }
    } catch (error) {
      console.error("Error setting language:", error);
    }
  }

  private async addTokenToHeaders() {
    try {
      const token = localStorage.getItem("token");
      if (token) {
        this.api.defaults.headers.common["Authorization"] = `Bearer ${token}`;
      } else {
        delete this.api.defaults.headers.common["Authorization"];
      }
    } catch (error) {
      console.error("Error setting token:", error);
    }
  }

  private setupInterceptors() {
    this.api.interceptors.request.use(
      async (config) => {
        await this.addLanguageToHeaders();
        await this.addTokenToHeaders();
        return config;
      },
      (error) => {
        return Promise.reject(error);
      },
    );

    this.api.interceptors.response.use(
      (response) => response,
      (error) => {
        if (error.response) {
          const status = error.response.status;
          if (status === 401) {
            throw new Error(translate("common.errors.expiredToken"));
          } else if (status === 403) {
            throw new Error(translate("common.errors.unauthorizedAccess"));
          } else {
            throw new Error(error.response.data.detail || error.message);
          }
        } else {
          throw new Error(error.message);
        }
      },
    );
  }

  public async post<T = any>(
    url: string,
    data?: any,
    config?: AxiosRequestConfig,
  ): Promise<T> {
    const response: AxiosResponse<T> = await this.api.post(url, data, config);
    return response.data;
  }
}

export default ApiService;
