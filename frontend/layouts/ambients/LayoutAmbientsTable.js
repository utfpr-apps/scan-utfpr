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
  Spinner,
} from "@chakra-ui/react";
import QRCode from "react-qr-code";

import { useQueryListAmbients } from "service/ambients";

import LayoutAmbientsTableActions from "./LayoutAmbientsTableActions";
import Link from "next/link";

const LayoutAmbientsTable = () => {
  const { data, isLoading } = useQueryListAmbients();

  if (isLoading) {
    return (
      <Flex flex={1} direction="column" align="center" justify="center">
        <Spinner
          thickness="4px"
          speed="0.65s"
          emptyColor="gray.200"
          color="primary"
          size="xl"
        />
      </Flex>
    );
  }

  return (
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
          {data.map((ambient) => (
            <Tr key={ambient.id}>
              <Td>{ambient.codigoSala}</Td>
              <Td>
                <Box ml="10px">
                  <Link href={`/qrcode/${ambient.codigoSala}`} passHref>
                    <Button variant="ghost">
                      <Image
                        src="/assets/qrcode.png"
                        height={31}
                        width={31}
                        alt="geração do qrcode"
                      />
                    </Button>
                  </Link>
                </Box>
              </Td>
              <Td>{ambient.tamanhoBloco}</Td>
              <Td isNumeric>
                <LayoutAmbientsTableActions ambient={ambient} />
              </Td>
            </Tr>
          ))}
        </Tbody>
      </Table>
    </TableContainer>
  );
};

export default LayoutAmbientsTable;
