import { Box, Text, Flex } from "@chakra-ui/react";

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
  </Flex>
);

export default LayoutRoomsHeader;
