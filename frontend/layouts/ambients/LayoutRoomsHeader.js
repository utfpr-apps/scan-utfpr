import dynamic from "next/dynamic";

import { Box, Text, Flex, Button, useDisclosure } from "@chakra-ui/react";

import { FaFilter } from "react-icons/fa";
import { BsSortUp } from "react-icons/bs";
import { MdAdd } from "react-icons/md";

const LayoutAmbientsModalCreate = dynamic(() =>
  import("./LayoutAmbientsModalCreate")
);

const LayoutRoomsHeader = () => {
  const { isOpen, onOpen, onClose } = useDisclosure();

  return (
    <>
      <Flex justify="space-between">
        <Box>
          <Text color="blackText" fontSize="19px" fontWeight="bold">
            Ambientes da UTFPR
          </Text>

          <Text color="greyText" fontSize="12px" fontWeight={400} mt="8px">
            Aqui você pode gerar os QRCodes para cada sala de aula ou ambiente
            da UTFPR.
          </Text>
        </Box>

        <Flex color="greyText">
          <Button
            background="primary"
            color="blackText"
            mr="30px"
            leftIcon={<MdAdd />}
            onClick={onOpen}
          >
            Criar Ambiente
          </Button>

          <Button variant="ghost" leftIcon={<FaFilter size={12} />}>
            Ordenar
          </Button>
          <Button variant="ghost" leftIcon={<BsSortUp />}>
            Filtrar
          </Button>
        </Flex>
      </Flex>

      <LayoutAmbientsModalCreate isOpen={isOpen} onClose={onClose} />
    </>
  );
};

export default LayoutRoomsHeader;
