import { Box, Text, Flex, Button, useDisclosure } from "@chakra-ui/react";

import { FaFilter } from "react-icons/fa";
import { BsSortUp } from "react-icons/bs";
import { MdAdd } from "react-icons/md";
import LayoutUsetsTableModalCreate from "./LayoutUsetsTableModalCreate";

const LayoutUsersHeader = () => {
  const { isOpen, onOpen, onClose } = useDisclosure();

  return (
    <>
      <Flex justify="space-between">
        <Box>
          <Text color="blackText" fontSize="19px" fontWeight="bold">
            Usuários do Painel Administrativo
          </Text>

          <Text color="greyText" fontSize="12px" fontWeight={400} mt="8px">
            Aqui você pode gerenciar os usuários que terão acesso ao painel do
            SCAN
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
            Adicionar Usuário
          </Button>

          <Button variant="ghost" leftIcon={<FaFilter size={12} />}>
            Ordenar
          </Button>
          <Button variant="ghost" leftIcon={<BsSortUp />}>
            Filtrar
          </Button>
        </Flex>
      </Flex>

      <LayoutUsetsTableModalCreate isOpen={isOpen} onClose={onClose} />
    </>
  );
};

export default LayoutUsersHeader;
