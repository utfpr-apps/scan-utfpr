import React from "react";
import { extendTheme, ChakraProvider } from "@chakra-ui/react";

import { QueryClient, QueryClientProvider } from "react-query";

import "../styles/globals.css";

import Navbar from "../components/Navbar";
import Sidebar from "../components/Sidebar";

const colors = {
  blackText: "#252733",
};

const theme = extendTheme({ colors });

function MyApp({ Component, pageProps }) {
  const [queryClient] = React.useState(() => new QueryClient());

  return (
    <QueryClientProvider client={queryClient}>
      <ChakraProvider theme={theme}>
        <Navbar />
        <Sidebar />

        <Component {...pageProps} />
      </ChakraProvider>
    </QueryClientProvider>
  );
}

export default MyApp;
