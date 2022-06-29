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
  Spinner,
} from "@chakra-ui/react";
import { format } from "date-fns";
import { useQueryListEmailNotifications } from "service/notifications";

const LayoutNotificationsTableActionsStudents = ({ notification }) => {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const toast = useToast();

  const [data, isLoading] = useQueryListEmailNotifications();

  if (isLoading) {
    return (
      <Flex height="100vh" align="center" justify="center">
        <Spinner size="lg" color="yellow" />
      </Flex>
    );
  }

  const handleCopyEmails = () => {
    const emails = data.map((email) => email);

    navigator.clipboard.writeText(emails.toString());

    toast({
      description: "Os emails foram copiados com sucesso",
      status: "success",
      duration: 9000,
      isClosable: true,
    });
  };

  return (
    <>
      <MenuItem onClick={onOpen}>Alunos envolvidos</MenuItem>

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
              >{`Notificação registrada pelo estudante ${notification.usuarioNome}`}</Text>

              <Text
                mt="10px"
                fontWeight={600}
                textAlign="center"
              >{`Data do registro: ${format(
                notification.dataInicialAfastamento,
                "dd/MM/yyyy"
              )}`}</Text>
              <Text
                fontWeight={600}
                textAlign="center"
              >{`Data limite do atestado: ${format(
                notification.dataFinalAfastamento,
                "dd/MM/yyyy"
              )}`}</Text>

              <Text mt="50px">
                Os emails dos alunos envolvidos nessa notificação são:
              </Text>

              <Flex direction="column" ml="30px" mt="15px">
                {data.map((student, index) => (
                  <Flex key={index}>
                    <Text ml="5px">{student.email}</Text>
                  </Flex>
                ))}
              </Flex>
            </Flex>
          </ModalBody>

          <ModalFooter mt="20px" justifyContent="space-between">
            <Button variant="ghost" onClick={onClose}>
              Fechar
            </Button>

            <Button
              variant="outline"
              background="primary"
              mr="10px"
              onClick={handleCopyEmails}
            >
              Copiar emails
            </Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </>
  );
};

export default LayoutNotificationsTableActionsStudents;
