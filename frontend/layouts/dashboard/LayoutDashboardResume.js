import { Flex } from "@chakra-ui/react";

import LayoutDashboardStatusCard from "./LayoutDashboardStatusCard";

const notificationsStatus = [
  { title: "Casos Encerrados", quantity: 16 },
  { title: "Casos em Aberto", quantity: 5 },
  { title: "Total de Casos", quantity: 23 },
];

const LayoutDashboardResume = () => {
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
