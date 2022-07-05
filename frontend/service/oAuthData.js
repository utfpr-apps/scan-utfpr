import { useMutation } from "react-query";
import getApi from "service";

const BASE_URL = process.env.NEXT_PUBLIC_BASE_API_URL;

export const useMutationLogin = (options) =>
  useMutation(
    (oAuthData) =>
      axios
        .post(`${BASE_URL}/auth/login-usuario-admin`, oAuthData)
        .then((result) => result.data.userDataViewModel),
    options
  );

export const useMutationCreateUser = (options = {}) => {
  const api = getApi();

  return useMutation(
    (oAuthData) =>
      api
        .post(`${BASE_URL}/auth/criar-usuario-admin`, oAuthData)
        .then((result) => result.data.data),
    options
  );
};
