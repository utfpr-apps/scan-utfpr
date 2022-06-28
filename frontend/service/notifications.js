import axios from "axios";

import { useQuery } from "react-query";

const BASE_URL = process.env.NEXT_PUBLIC_BASE_API_URL;

export const useQueryListNotifications = (options = {}) =>
  useQuery(
    ["queryListNotifications"],
    () => axios.get(`${BASE_URL}/notificacoes`).then((result) => result.data),
    { retry: false, ...options }
  );

export const useQueryListOpenNotifications = (options = {}) =>
  useQuery(
    ["queryListOpenNotifications"],
    () =>
      axios
        .get(`${BASE_URL}/notificacoes/notificacoes-abertas`)
        .then((result) => result.data),
    {
      retry: false,
      ...options,
    }
  );
