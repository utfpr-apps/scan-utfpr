import { Box, Text, Flex } from "@chakra-ui/react";

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
  </Flex>
);

export default LayoutNotificationsHeader;
