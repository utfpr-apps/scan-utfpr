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
} from "@chakra-ui/react";

const LayoutNotificationsTableActionsRemoveNotification = ({
  notification,
}) => {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const toast = useToast();

  const handleRemoveNotification = () => {
    toast({
      description: "A notificação foi removida com sucesso",
      status: "success",
      duration: 9000,
      isClosable: true,
    });

    onClose();
  };

  return (
    <>
      <MenuItem onClick={onOpen}>Remover notificação</MenuItem>

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
              >{`Deseja remover a notificação do aluno ${notification.student}?`}</Text>

              <Text
                mt="10px"
                fontWeight={600}
                textAlign="center"
              >{`Data do registro: ${notification.date}`}</Text>
              <Text
                fontWeight={600}
                textAlign="center"
              >{`Data limite do atestado: ${notification.dateLimit}`}</Text>
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
              onClick={handleRemoveNotification}
            >
              Remover
            </Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </>
  );
};

export default LayoutNotificationsTableActionsRemoveNotification;
