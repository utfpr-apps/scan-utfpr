import axios from "axios";

import { useQuery, useMutation } from "react-query";

const BASE_URL = process.env.NEXT_PUBLIC_BASE_API_URL;

export const useQueryListAmbients = (options = {}) =>
  useQuery(
    ["queryListAmbients"],
    () => axios.get(`${BASE_URL}/ambientes`).then((result) => result.data),
    options
  );

export const useMutationCreateAmbients = (options = {}) =>
  useMutation(
    (ambientData) =>
      axios
        .post(`${BASE_URL}/ambientes`, ambientData)
        .then((result) => result.data),
    options
  );

export const useMutationRemoveAmbients = (options = {}) =>
  useMutation(
    (ambientId) =>
      axios
        .delete(`${BASE_URL}/ambientes/${ambientId}`)
        .then((result) => result.data),
    options
  );

export const useMutationEditAmbients = (options = {}) =>
  useMutation(
    (ambientData) =>
      axios
        .put(`${BASE_URL}/ambientes/${ambientData.id}`, ambientData)
        .then((result) => result.data),
    options
  );
