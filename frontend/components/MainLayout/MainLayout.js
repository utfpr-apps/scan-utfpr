import { useEffect, useState } from "react";

import { useRouter } from "next/router";

import {
  Box,
  Button,
  Flex,
  Spinner,
  useBreakpointValue,
} from "@chakra-ui/react";

import { useSession, signOut } from "next-auth/react";

import Navbar from "components/Navbar";
import Sidebar from "components/Sidebar";
import { useMutationLogin } from "service/oAuthData";
import getApi from "service";

const smVariant = { navigation: "drawer", navigationButton: true };
const mdVariant = { navigation: "sidebar", navigationButton: false };

const MainLayout = ({ children }) => {
  const { status, data } = useSession();

  const { mutate, isLoading } = useMutationLogin({
    onSuccess: (data) => {
      if (data.token) {
        window.localStorage.setItem("__SCANUTFPR_auth_token", data.token);

        getApi();
        return;
      }

      signOut();
    },
  });

  useEffect(() => {
    if (data?.googleToken) {
      mutate({
        provider: "google",
        token: data.googleToken,
      });
    }
  }, [data, mutate]);

  const router = useRouter();

  const [isSidebarOpen, setSidebarOpen] = useState(false);

  const variants = useBreakpointValue({ base: smVariant, md: mdVariant });

  const toggleSidebar = () => setSidebarOpen(!isSidebarOpen);

  if (status === "loading" || isLoading) {
    return (
      <Flex height="100vh" align="center" justify="center">
        <Spinner size="lg" color="yellow" />
      </Flex>
    );
  }

  if (status === "unauthenticated") {
    router.replace("/login");
  }

  return (
    <>
      <Navbar
        toggleSidebar={toggleSidebar}
        showSidebarButton={variants?.navigationButton}
      />

      <Flex>
        <Sidebar
          variant={variants?.navigation}
          isOpen={isSidebarOpen}
          toggleSidebar={toggleSidebar}
        />
        <Box width="100%">{children}</Box>
      </Flex>
    </>
  );
};

export default MainLayout;
