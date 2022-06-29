import { Box, Text, Flex, Button, useDisclosure } from "@chakra-ui/react";
import dynamic from "next/dynamic";

import { MdAdd } from "react-icons/md";

const LayoutUsetsTableModalCreate = dynamic(() =>
  import("./LayoutUsetsTableModalCreate")
);

const LayoutUsersHeader = () => {
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
            Usuários do Painel Administrativo
          </Text>

          <Text color="greyText" fontSize="12px" fontWeight={400} mt="8px">
            Aqui você pode gerenciar os usuários que terão acesso ao painel do
            SCAN
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
            Adicionar Usuário
          </Button>
        </Flex>
      </Flex>

      <LayoutUsetsTableModalCreate isOpen={isOpen} onClose={onClose} />
    </>
  );
};

export default LayoutUsersHeader;
