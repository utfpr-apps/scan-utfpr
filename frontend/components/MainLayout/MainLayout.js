import { useState } from "react";

import { useRouter } from "next/router";

import { Box, Flex, Spinner, useBreakpointValue } from "@chakra-ui/react";

import { useSession } from "next-auth/react";

import Navbar from "components/Navbar";
import Sidebar from "components/Sidebar";

const smVariant = { navigation: "drawer", navigationButton: true };
const mdVariant = { navigation: "sidebar", navigationButton: false };

const MainLayout = ({ children }) => {
  const { status } = useSession();

  const router = useRouter();

  const [isSidebarOpen, setSidebarOpen] = useState(false);

  const variants = useBreakpointValue({ base: smVariant, md: mdVariant });

  const toggleSidebar = () => setSidebarOpen(!isSidebarOpen);

  if (status === "loading") {
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
