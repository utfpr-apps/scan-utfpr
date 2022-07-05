import {
  Flex,
  Spinner,
  Text,
  Table,
  Thead,
  Tbody,
  Tr,
  Th,
  Td,
  TableContainer,
} from "@chakra-ui/react";

import { format } from "date-fns";

import { useQueryListOpenNotifications } from "service/notifications";

import LayoutNotificationsBadge from "./LayoutNotificationsBadge";
import LayoutNotificationsTableActions from "./LayoutNotificationsTableActions";

const LayoutNotificationsTable = () => {
  const { data = [], status, isLoading } = useQueryListOpenNotifications();

  if (isLoading) {
    return (
      <Flex height="100vh" align="center" justify="center">
        <Spinner size="lg" color="yellow" />
      </Flex>
    );
  }

  if (status === "error") {
    return (
      <Text
        mt="50px"
        color="blackText"
        fontSize="19px"
        fontWeight="bold"
        textAlign="center"
      >
        Ocorreu um erro ao buscar as notificações. Pode tentar novamente?
      </Text>
    );
  }

  if (data.length === 0) {
    return (
      <Text
        mt="50px"
        color="blackText"
        fontSize="19px"
        fontWeight="bold"
        textAlign="center"
      >
        Nenhuma notificação em aberto no momento
      </Text>
    );
  }

  return (
    <TableContainer mt="60px">
      <Table variant="simple">
        <Thead>
          <Tr>
            <Th>
              <Text color="greyText" fontSize="18px" fontWeight="semiBold">
                Nome do Aluno
              </Text>
            </Th>

            <Th>
              <Text color="greyText" fontSize="18px" fontWeight="semiBold">
                Data Diagnóstico
              </Text>
            </Th>

            <Th>
              <Text color="greyText" fontSize="18px" fontWeight="semiBold">
                Prazo Atestado
              </Text>
            </Th>

            <Th>
              <Text color="greyText" fontSize="18px" fontWeight="semiBold">
                Status
              </Text>
            </Th>

            <Th></Th>
          </Tr>
        </Thead>

        <Tbody>
          {data.map((notification, index) => (
            <Tr key={index}>
              <Td>{notification.usuarioNome}</Td>
              <Td>
                {format(notification.dataInicialAfastamento, "dd/MM/yyy")}
              </Td>
              <Td>{format(notification.dataFinalAfastamento, "dd/MM/yyy")}</Td>
              <Td>
                <LayoutNotificationsBadge status={notification.status} />
              </Td>

              <Td isNumeric>
                <LayoutNotificationsTableActions notification={notification} />
              </Td>
            </Tr>
          ))}
        </Tbody>
      </Table>
    </TableContainer>
  );
};

export default LayoutNotificationsTable;
