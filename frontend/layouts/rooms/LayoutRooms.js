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
import { IoQrCode } from "react-icons/io5";

import Container from "components/Container";
import PageLayout from "components/PageLayout";

const rooms = [
  { acronym: "V101", interval: "50 Minutos" },
  { acronym: "V102", interval: "50 Minutos" },
  { acronym: "V103", interval: "50 Minutos" },
  { acronym: "V104", interval: "50 Minutos" },
];

const LayoutRooms = () => {
  return (
    <PageLayout pageTitle="Salas e Ambientes">
      <Container my="25px" direction="column" flex={1} p="32px">
        <Text color="blackText" fontSize="19px" fontWeight="bold">
          Salas e Ambientes da UTFPR
        </Text>

        <Text color="greyText" fontSize="12px" fontWeight={400} mt="8px">
          Aqui você pode gerar os QRCodes para cada sala de aula ou ambiente da
          UTFPR.
        </Text>

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
              </Tr>
            </Thead>

            <Tbody>
              {rooms.map((room, index) => (
                <Tr key={index}>
                  <Td>{room.acronym}</Td>
                  <Td>
                    <IoQrCode />
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
      </Container>
    </PageLayout>
  );
};

export default LayoutRooms;
