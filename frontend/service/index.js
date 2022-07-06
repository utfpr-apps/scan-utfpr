import axios from "axios";

const getApi = () => {
  const api = axios.create({
    baseURL: process.env.NEXT_PUBLIC_BASE_API_URL,
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  });

  const token = window.localStorage.getItem("__SCANUTFPR_auth_token");
  api.defaults.headers.common.Authorization = `Bearer ${token}`;

  return api;
};

export default getApi;
