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
  Checkbox,
} from "@chakra-ui/react";

const students = [
  { name: "Felipe Maccari", email: "felipe@maccari.com.br" },
  { name: "Felipe Maccari", email: "felipe@maccari.com.br" },
  { name: "Felipe Maccari", email: "felipe@maccari.com.br" },
  { name: "Felipe Maccari", email: "felipe@maccari.com.br" },
  { name: "Felipe Maccari", email: "felipe@maccari.com.br" },
  { name: "Felipe Maccari", email: "felipe@maccari.com.br" },
  { name: "Felipe Maccari", email: "felipe@maccari.com.br" },
  { name: "Felipe Maccari", email: "felipe@maccari.com.br" },
];

const LayoutNotificationsTableActionsStudents = ({ notification }) => {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const toast = useToast();

  const handleCopyEmails = () => {
    const emails = students.map((student) => student.email);

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
              >{`Notificação registrada pelo estudante ${notification.student}`}</Text>

              <Text
                mt="10px"
                fontWeight={600}
                textAlign="center"
              >{`Data do registro: ${notification.date}`}</Text>
              <Text
                fontWeight={600}
                textAlign="center"
              >{`Data limite do atestado: ${notification.dateLimit}`}</Text>

              <Text mt="50px">Os alunos envolvidos nessa notificação são:</Text>

              <Flex direction="column" ml="30px" mt="15px">
                {students.map((student, index) => (
                  <Flex key={index}>
                    <Text fontWeight={700} mr="5px">
                      {student.name}
                    </Text>
                    - <Text ml="5px">{student.email}</Text>
                  </Flex>
                ))}
              </Flex>

              <Checkbox defaultChecked mt="50px" ml="25px">
                Alterar o status da notificação para{" "}
                <strong>Em Andamento</strong>
              </Checkbox>
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
