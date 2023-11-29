import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from "axios";

export class ApiServiceConfig {
  static logout: () => void;
}

class ApiService {
  protected api: AxiosInstance;

  constructor() {
    this.api = axios.create({
      baseURL: process.env.REACT_APP_API_URL,
    });

    this.setupInterceptors();
  }

  private async addLanguageToHeaders(config: AxiosRequestConfig) {
    try {
      const language = localStorage.getItem("language");
      if (language) {
        config.headers = {
          ...config.headers,
          Language: language,
        };
      }
    } catch (error) {
      console.error("Error setting language:", error);
    }
  }

  private async addTokenToHeaders(config: AxiosRequestConfig) {
    try {
      const token = localStorage.getItem("token");
      if (token) {
        config.headers = {
          ...config.headers,
          Authorization: `Bearer ${token}`,
        };
      }
    } catch (error) {
      console.error("Error setting token:", error);
    }
  }

  private setupInterceptors() {
    this.api.interceptors.request.use(
      async (config) => {
        await this.addLanguageToHeaders(config);
        await this.addTokenToHeaders(config);
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
          console.log(error.response.data);
          if (status === 401) {
            ApiServiceConfig.logout();
            throw new Error(error.response.data.detail);
          } else if (status === 403) {
            throw new Error(error.response.data.detail);
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

  public async get<T = any>(
    url: string,
    config?: AxiosRequestConfig,
  ): Promise<T> {
    const response: AxiosResponse<T> = await this.api.get(url, config);
    return response.data;
  }
}

export default ApiService;
