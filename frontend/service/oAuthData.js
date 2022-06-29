import axios from "axios";

import { useMutation } from "react-query";

const BASE_URL = process.env.NEXT_PUBLIC_BASE_API_URL;

export const useMutationLogin = (options = {}) =>
  useMutation(
    (oAuthData) =>
      axios
        .post(`${BASE_URL}/auth/login-usuario-admin`, oAuthData)
        .then((result) => result.data.data),
    { retry: false, ...options }
  );

export const useMutationCreateUser = (options = {}) =>
  useMutation(
    (oAuthData) =>
      axios
        .post(`${BASE_URL}/auth/criar-usuario-admin`, oAuthData)
        .then((result) => result.data.data),
    options
  );
