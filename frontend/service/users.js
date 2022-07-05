import { useQuery, useMutation } from "react-query";
import getApi from "service";

const BASE_URL = process.env.NEXT_PUBLIC_BASE_API_URL;

export const useQueryListUsers = (options = {}) => {
  const api = getApi();

  return useQuery(
    ["queryListUsers"],
    () => api.get(`${BASE_URL}/auth`).then((result) => result.data),
    options
  );
};

export const useMutationCreateUser = (options = {}) => {
  const api = getApi();

  return useMutation(
    (userData) =>
      api
        .post(`${BASE_URL}/auth/criar-usuario-admin`, userData)
        .then((result) => result.data),
    options
  );
};

export const useMutationRemoveUser = (options = {}) => {
  const api = getApi();

  return useMutation(
    (userId) =>
      api.delete(`${BASE_URL}/auth/${userId}`).then((result) => result.data),
    options
  );
};
