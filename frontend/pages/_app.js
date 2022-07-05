import { useState } from "react";
import { extendTheme, ChakraProvider } from "@chakra-ui/react";
import { createBreakpoints } from "@chakra-ui/theme-tools";

import { QueryClient, QueryClientProvider } from "react-query";

import { SessionProvider } from "next-auth/react";

import "../styles/globals.css";
import "service";

const breakpoints = createBreakpoints({
  sm: "30em",
  md: "48em",
  lg: "62em",
  xl: "80em",
  "2xl": "96em",
});

const colors = {
  primary: "#FECC00",
  blackText: "#252733",
  greyText: "#9FA2B4",

  lightBackground: "#f0f1f6",
  yellow: "#ffcc00",
};

const theme = extendTheme({ colors, breakpoints });

function MyApp({ Component, pageProps: { session, ...pageProps } }) {
  const [queryClient] = useState(
    () =>
      new QueryClient({
        defaultOptions: {
          queries: {
            refetchOnWindowFocus: false,
          },
        },
      })
  );

  return (
    <SessionProvider session={session}>
      <QueryClientProvider client={queryClient}>
        <ChakraProvider theme={theme} resetCSS>
          <Component {...pageProps} />
        </ChakraProvider>
      </QueryClientProvider>
    </SessionProvider>
  );
}

export default MyApp;
