import { useQuery, useMutation } from "react-query";
import getApi from "service";

const BASE_URL = process.env.NEXT_PUBLIC_BASE_API_URL;

export const useQueryListAmbients = (options = {}) => {
  const api = getApi();

  return useQuery(
    ["queryListAmbients"],
    () => api.get(`${BASE_URL}/ambientes`).then((result) => result.data),
    options
  );
};

export const useMutationCreateAmbients = (options = {}) => {
  const api = getApi();

  return useMutation(
    (ambientData) =>
      api
        .post(`${BASE_URL}/ambientes`, ambientData)
        .then((result) => result.data),
    options
  );
};

export const useMutationRemoveAmbients = (options = {}) => {
  const api = getApi();

  return useMutation(
    (ambientId) =>
      api
        .delete(`${BASE_URL}/ambientes/${ambientId}`)
        .then((result) => result.data),
    options
  );
};

export const useMutationEditAmbients = (options = {}) => {
  const api = getApi();

  return useMutation(
    (ambientData) =>
      api
        .put(`${BASE_URL}/ambientes/${ambientData.id}`, ambientData)
        .then((result) => result.data),
    options
  );
};
