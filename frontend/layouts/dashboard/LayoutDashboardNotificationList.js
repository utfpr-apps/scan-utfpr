import { Box, Flex, Text, Spinner } from "@chakra-ui/react";

import Container from "components/Container";
import { useQueryListOpenNotifications } from "service/notifications";

const notifications = [
  { name: "Felipe", date: "01/04/2022" },
  { name: "Cesar", date: "01/04/2022" },
  { name: "Maccari", date: "01/04/2022" },
  { name: "Felipe Cesar", date: "01/04/2022" },
];

const LayoutDashboardNotificationList = () => {
  const { data = [], isLoading } = useQueryListOpenNotifications();

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
        {data.length === 0 ? (
          <Text
            color="blackText"
            fontSize="19px"
            fontWeight="bold"
            textAlign="center"
          >
            Nenhuma notificação em aberto no momento
          </Text>
        ) : (
          <>
            <Flex width="100%" justify="space-between" mb="10px">
              <Text color="greyText" fontSize="18px" fontWeight="semiBold">
                Aluno
              </Text>
              <Text color="greyText" fontSize="18px" fontWeight="semiBold">
                Prazo do Atestado
              </Text>
            </Flex>

            {notifications.map((notification, index) => (
              <Flex
                key={index}
                width="100%"
                justify="space-between"
                py="20px"
                borderBottom="1px solid #DFE0EB"
              >
                <Text color="blackText" fontSize="14px" fontWeight="semiBold">
                  {notification.name}
                </Text>
                <Text color="greyText" fontSize="14px" fontWeight="semiBold">
                  {notification.date}
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
