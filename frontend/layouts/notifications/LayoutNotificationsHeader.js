import { Box, Text, Flex, Button } from "@chakra-ui/react";

import { FaFilter } from "react-icons/fa";
import { BsSortUp } from "react-icons/bs";

const LayoutNotificationsHeader = () => (
  <Flex justify="space-between">
    <Box>
      <Text color="blackText" fontSize="19px" fontWeight="bold">
        Todas as notificações
      </Text>

      <Text color="greyText" fontSize="12px" fontWeight={400} mt="8px">
        Aqui você pode acompanhar todas as notificações e seus respectivos
        status e informações detalhadas
      </Text>
    </Box>

    <Flex color="greyText">
      <Button variant="ghost" leftIcon={<FaFilter size={12} />}>
        Ordenar
      </Button>
      <Button variant="ghost" leftIcon={<BsSortUp />}>
        Filtrar
      </Button>
    </Flex>
  </Flex>
);

export default LayoutNotificationsHeader;
