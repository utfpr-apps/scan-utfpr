import { Flex, Spinner } from "@chakra-ui/react";
import { useQueryListNotifications } from "service/notifications";

import LayoutDashboardStatusCard from "./LayoutDashboardStatusCard";

const LayoutDashboardResume = () => {
  const { data, isLoading } = useQueryListNotifications();

  const notificationsStatus = [
    { title: "Casos Encerrados", quantity: data?.casosEncerrados || 0 },
    { title: "Casos em Aberto", quantity: data?.casosAbertos || 0 },
    { title: "Total de Casos", quantity: data?.total || 0 },
  ];

  if (isLoading) {
    return (
      <Flex height="100vh" align="center" justify="center">
        <Spinner size="lg" color="yellow" />
      </Flex>
    );
  }

  return (
    <Flex
      width="100%"
      mt="34px"
      justify={["center", "center", "space-between"]}
      flexWrap="wrap"
    >
      {notificationsStatus.map((status, index) => (
        <LayoutDashboardStatusCard status={status} key={index} />
      ))}
    </Flex>
  );
};

export default LayoutDashboardResume;
