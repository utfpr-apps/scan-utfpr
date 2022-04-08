import { Flex } from "@chakra-ui/react";

import PageTitle from "components/PageTitle";
import LayoutDashboardNotificationList from "./LayoutDashboardNotificationList";
import LayoutDashboardResume from "./LayoutDashboardResume";

const LayoutDashboard = () => {
  return (
    <Flex
      width="100%"
      px="30px"
      direction="column"
      minHeight="calc(100vh - 93px)"
    >
      <PageTitle>Página Inicial</PageTitle>

      <LayoutDashboardResume />

      <LayoutDashboardNotificationList />
    </Flex>
  );
};

export default LayoutDashboard;
