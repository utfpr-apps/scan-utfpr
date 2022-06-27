import dynamic from "next/dynamic";

import { Box, Text, Flex, Button, useDisclosure } from "@chakra-ui/react";

import { FaFilter } from "react-icons/fa";
import { BsSortUp } from "react-icons/bs";
import { MdAdd } from "react-icons/md";

const LayoutAmbientsModalCreate = dynamic(() =>
  import("./LayoutAmbientsModalCreate")
);

const LayoutAmbientsHeader = () => {
  const { isOpen, onOpen, onClose } = useDisclosure();

  return (
    <>
      <Flex
        justify="space-between"
        direction={["column", "column", "row"]}
        align={["center", "center", "flex-start"]}
      >
        <Box>
          <Text color="blackText" fontSize="19px" fontWeight="bold">
            Ambientes da UTFPR
          </Text>

          <Text color="greyText" fontSize="12px" fontWeight={400} mt="8px">
            Aqui você pode gerar os QRCodes para cada sala de aula ou ambiente
            da UTFPR.
          </Text>
        </Box>

        <Flex
          color="greyText"
          mt={["30px", "30px", "0"]}
          mr={["0", "0", "30px"]}
        >
          <Button
            background="primary"
            color="blackText"
            leftIcon={<MdAdd />}
            onClick={onOpen}
          >
            Criar Ambiente
          </Button>
        </Flex>
      </Flex>

      <LayoutAmbientsModalCreate isOpen={isOpen} onClose={onClose} />
    </>
  );
};

export default LayoutAmbientsHeader;
