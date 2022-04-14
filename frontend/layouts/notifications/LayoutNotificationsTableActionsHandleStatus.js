import {
  Button,
  MenuItem,
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalFooter,
  ModalBody,
  ModalCloseButton,
  useDisclosure,
  Flex,
  Text,
  useToast,
  Select,
} from "@chakra-ui/react";

const LayoutNotificationsTableActionsHandleStatus = ({ notification }) => {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const toast = useToast();

  const handleChangeStatus = () => {
    toast({
      description: "O status foi alterado com sucesso",
      status: "success",
      duration: 9000,
      isClosable: true,
    });

    onClose();
  };

  return (
    <>
      <MenuItem onClick={onOpen}>Alterar status</MenuItem>

      <Modal isOpen={isOpen} onClose={onClose} size="xl">
        <ModalOverlay />
        <ModalContent>
          <ModalHeader></ModalHeader>
          <ModalCloseButton />
          <ModalBody mt="15px">
            <Flex justify="center" direction="column">
              <Text
                fontWeight="bold"
                textAlign="center"
                textDecor="underline"
              >{`Deseja alterar o status da notificação do aluno ${notification.student}?`}</Text>

              <Text
                mt="10px"
                fontWeight={600}
                textAlign="center"
              >{`Data do registro: ${notification.date}`}</Text>
              <Text
                fontWeight={600}
                textAlign="center"
              >{`Data limite do atestado: ${notification.dateLimit}`}</Text>

              <Text
                fontWeight={600}
                textAlign="center"
              >{`Status: ${notification.status}`}</Text>

              <Text mt="50px" mb="10px">
                Selecione o novo status da notificação:
              </Text>

              <Select placeholder="Selecione">
                <option value="option1">Não notificado</option>
                <option value="option2">Em andamento</option>
                <option value="option3">Finalizada</option>
              </Select>
            </Flex>
          </ModalBody>

          <ModalFooter mt="20px" justifyContent="space-between">
            <Button variant="ghost" onClick={onClose}>
              Cancelar
            </Button>

            <Button
              variant="outline"
              background="primary"
              mr="10px"
              onClick={handleChangeStatus}
            >
              Alterar
            </Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </>
  );
};

export default LayoutNotificationsTableActionsHandleStatus;
