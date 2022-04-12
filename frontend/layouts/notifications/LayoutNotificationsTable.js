import Image from "next/image";

import {
  Box,
  Text,
  Table,
  Thead,
  Tbody,
  Tr,
  Th,
  Td,
  TableContainer,
  Button,
  Flex,
} from "@chakra-ui/react";

import { BiDotsVerticalRounded } from "react-icons/bi";

import LayoutNotificationsBadge from "./LayoutNotificationsBadge";

const notifications = [
  {
    student: "Felipe Maccari",
    room: "V105",
    date: "14/Março/2022",
    dateLimit: "14/Março/2022",
    status: 0,
  },
  {
    student: "Felipe Maccari",
    room: "V105",
    date: "14/Março/2022",
    dateLimit: "14/Março/2022",
    status: 1,
  },
  {
    student: "Felipe Maccari",
    room: "V105",
    date: "14/Março/2022",
    dateLimit: "14/Março/2022",
    status: 2,
  },
  {
    student: "Felipe Maccari",
    room: "V105",
    date: "14/Março/2022",
    dateLimit: "14/Março/2022",
    status: 0,
  },
];

const LayoutNotificationsTable = () => (
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
              Sala
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
        {notifications.map((notification, index) => (
          <Tr key={index}>
            <Td>{notification.student}</Td>
            <Td>{notification.room}</Td>
            <Td>{notification.date}</Td>
            <Td>{notification.dateLimit}</Td>
            <Td>
              <LayoutNotificationsBadge status={notification.status} />
            </Td>
            <Td isNumeric>
              <Button variant="ghost">
                <BiDotsVerticalRounded />
              </Button>
            </Td>
          </Tr>
        ))}
      </Tbody>
    </Table>
  </TableContainer>
);

export default LayoutNotificationsTable;
