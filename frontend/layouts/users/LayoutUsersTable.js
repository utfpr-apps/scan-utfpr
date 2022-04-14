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

const users = [
  {
    name: "Felipe Maccari",
    email: "felipemaccari@utfpr.edu.br",
  },
  {
    name: "Felipe Maccari",
    email: "felipemaccari@utfpr.edu.br",
  },
  {
    name: "Felipe Maccari",
    email: "felipemaccari@utfpr.edu.br",
  },
  {
    name: "Felipe Maccari",
    email: "felipemaccari@utfpr.edu.br",
  },
  {
    name: "Felipe Maccari",
    email: "felipemaccari@utfpr.edu.br",
  },
];

const LayoutUsersTable = () => (
  <TableContainer mt="60px">
    <Table variant="simple">
      <Thead>
        <Tr>
          <Th>
            <Text color="greyText" fontSize="18px" fontWeight="semiBold">
              Nome do Usuário
            </Text>
          </Th>

          <Th>
            <Text color="greyText" fontSize="18px" fontWeight="semiBold">
              Email
            </Text>
          </Th>

          <Th></Th>
        </Tr>
      </Thead>

      <Tbody>
        {users.map((user, index) => (
          <Tr key={index}>
            <Td>{user.name}</Td>
            <Td>{user.email}</Td>

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

export default LayoutUsersTable;
