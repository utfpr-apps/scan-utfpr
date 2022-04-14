import React from "react";
import { extendTheme, ChakraProvider, Flex, Box } from "@chakra-ui/react";

import { QueryClient, QueryClientProvider } from "react-query";

import "../styles/globals.css";

import Navbar from "../components/Navbar";
import Sidebar from "../components/Sidebar";

const colors = {
  primary: "#FECC00",
  blackText: "#252733",
  greyText: "#9FA2B4",
};

const theme = extendTheme({ colors });

function MyApp({ Component, pageProps }) {
  const [queryClient] = React.useState(() => new QueryClient());

  return (
    <QueryClientProvider client={queryClient}>
      <ChakraProvider theme={theme} resetCSS>
        <Navbar />

        <Flex>
          <Sidebar />

          <Box width="100%">
            <Component {...pageProps} />
          </Box>
        </Flex>
      </ChakraProvider>
    </QueryClientProvider>
  );
}

export default MyApp;
