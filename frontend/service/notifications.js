import { useQuery } from "react-query";
import getApi from "service";

const BASE_URL = process.env.NEXT_PUBLIC_BASE_API_URL;

export const useQueryListNotifications = (options = {}) => {
  const api = getApi();

  return useQuery(
    ["queryListNotifications"],
    () => api.get(`${BASE_URL}/notificacoes`).then((result) => result.data),
    { retry: false, ...options }
  );
};

export const useQueryListOpenNotifications = (options = {}) => {
  const api = getApi();

  return useQuery(
    ["queryListOpenNotifications"],
    () =>
      api
        .get(`${BASE_URL}/notificacoes/notificacoes-abertas`)
        .then((result) => result.data),
    {
      retry: false,
      ...options,
    }
  );
};

export const useQueryListEmailNotifications = (
  notificationId,
  options = {}
) => {
  const api = getApi();

  return useQuery(
    ["queryListEmailNotifications"],
    () =>
      api
        .get(`${BASE_URL}/notificacoes/${notificationId}/emails`)
        .then((result) => result.data),
    {
      retry: false,
      ...options,
    }
  );
};
