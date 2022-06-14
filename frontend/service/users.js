import axios from "axios";

import { useQuery, useMutation } from "react-query";

const BASE_URL = process.env.NEXT_PUBLIC_BASE_API_URL;

export const useQueryListUsers = (options = {}) =>
  useQuery(
    ["queryListUsers"],
    () => axios.get(`${BASE_URL}/auth`).then((result) => result.data),
    options
  );

export const useMutationCreateUser = (options = {}) =>
  useMutation(
    (userData) =>
      axios
        .post(`${BASE_URL}/auth/criar-usuario-admin`, userData)
        .then((result) => result.data),
    options
  );

export const useMutationRemoveUser = (options = {}) =>
  useMutation(
    (userId) =>
      axios.delete(`${BASE_URL}/auth/${userId}`).then((result) => result.data),
    options
  );
