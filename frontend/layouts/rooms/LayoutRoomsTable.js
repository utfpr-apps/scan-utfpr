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
const rooms = [
  { acronym: "V101", interval: "50 Minutos" },
  { acronym: "V102", interval: "50 Minutos" },
  { acronym: "V103", interval: "50 Minutos" },
  { acronym: "V104", interval: "50 Minutos" },
];

const LayoutRoomsTable = () => (
  <TableContainer mt="60px">
    <Table variant="simple">
      <Thead>
        <Tr>
          <Th>
            <Text color="greyText" fontSize="18px" fontWeight="semiBold">
              Sigla
            </Text>
          </Th>

          <Th>
            <Text color="greyText" fontSize="18px" fontWeight="semiBold">
              QRCode
            </Text>
          </Th>

          <Th>
            <Text color="greyText" fontSize="18px" fontWeight="semiBold">
              Intervalo de Tempo
            </Text>
          </Th>

          <Th></Th>
        </Tr>
      </Thead>

      <Tbody>
        {rooms.map((room, index) => (
          <Tr key={index}>
            <Td>{room.acronym}</Td>
            <Td>
              <Box ml="10px">
                <Button variant="ghost">
                  <Image
                    src="/assets/qrcode.png"
                    height={31}
                    width={31}
                    alt="geração do qrcode"
                  />
                </Button>
              </Box>
            </Td>
            <Td>{room.interval}</Td>
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

export default LayoutRoomsTable;
