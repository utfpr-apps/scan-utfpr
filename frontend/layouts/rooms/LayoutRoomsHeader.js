import { Box, Text, Flex, Button } from "@chakra-ui/react";

import { FaFilter } from "react-icons/fa";
import { BsSortUp } from "react-icons/bs";

const LayoutRoomsHeader = () => (
  <Flex justify="space-between">
    <Box>
      <Text color="blackText" fontSize="19px" fontWeight="bold">
        Salas e Ambientes da UTFPR
      </Text>

      <Text color="greyText" fontSize="12px" fontWeight={400} mt="8px">
        Aqui você pode gerar os QRCodes para cada sala de aula ou ambiente da
        UTFPR.
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

export default LayoutRoomsHeader;
