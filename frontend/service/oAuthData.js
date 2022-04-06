import axios from "axios";

import { useMutation } from "react-query";

export const useMutationLogin = (options = {}) =>
  useMutation(
    (oAuthData) =>
      axios
        .post("https://utfpr-scan.herokuapp.com/api/auth", oAuthData)
        .then((result) => result.data.data),
    options
  );
