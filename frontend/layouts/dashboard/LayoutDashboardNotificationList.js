import { Box, Flex, Text, Spinner } from "@chakra-ui/react";

import Container from "components/Container";
import { useQueryListOpenNotifications } from "service/notifications";

const LayoutDashboardNotificationList = () => {
  const { data = [], status, isLoading } = useQueryListOpenNotifications();

  if (isLoading) {
    return (
      <Flex height="100vh" align="center" justify="center">
        <Spinner size="lg" color="yellow" />
      </Flex>
    );
  }

  return (
    <Container my="25px" direction="column" flex={1} p="32px">
      <Text color="blackText" fontSize="19px" fontWeight="bold">
        Notificações em andamento
      </Text>

      <Text color="greyText" fontSize="12px" fontWeight={400} mt="8px">
        As notificações em andamento são aquelas em que o atestado ainda não
        atingiu o prazo final
      </Text>

      <Box mt="60px" direction="column">
        {status === "error" && (
          <Text
            color="blackText"
            fontSize="19px"
            fontWeight="bold"
            textAlign="center"
          >
            Ocorreu um erro ao buscar as notificações. Pode tentar novamente?
          </Text>
        )}

        {status !== "error" && data.length === 0 && (
          <Text
            color="blackText"
            fontSize="19px"
            fontWeight="bold"
            textAlign="center"
          >
            Ocorreu um erro ao buscar as notificações. Pode tentar novamente?
          </Text>
        )}

        {status !== "error" && data.length > 0 && (
          <>
            <Flex width="100%" justify="space-between" mb="10px">
              <Text color="greyText" fontSize="18px" fontWeight="semiBold">
                Aluno
              </Text>
              <Text color="greyText" fontSize="18px" fontWeight="semiBold">
                Prazo do Atestado
              </Text>
            </Flex>

            {data.map((notification, index) => (
              <Flex
                key={index}
                width="100%"
                justify="space-between"
                py="20px"
                borderBottom="1px solid #DFE0EB"
              >
                <Text color="blackText" fontSize="14px" fontWeight="semiBold">
                  {notification.usuarioNome}
                </Text>
                <Text color="greyText" fontSize="14px" fontWeight="semiBold">
                  {notification.dataFinalAfastamento}
                </Text>
              </Flex>
            ))}
          </>
        )}
      </Box>
    </Container>
  );
};

export default LayoutDashboardNotificationList;
