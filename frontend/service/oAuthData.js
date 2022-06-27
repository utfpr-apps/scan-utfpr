import axios from "axios";

import { useMutation } from "react-query";

export const useMutationLogin = (options = {}) =>
  useMutation(
    (oAuthData) =>
      axios
        .post(
          "https://utfpr-scan.herokuapp.com/api/auth/login-usuario-admin",
          oAuthData
        )
        .then((result) => result.data.data),
    options
  );

export const useMutationCreateUser = (options = {}) =>
  useMutation(
    (oAuthData) =>
      axios
        .post(
          "https://utfpr-scan.herokuapp.com/api/auth/criar-usuario-admin",
          oAuthData
        )
        .then((result) => result.data.data),
    options
  );
