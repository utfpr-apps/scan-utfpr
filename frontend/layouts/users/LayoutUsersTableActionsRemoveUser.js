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
import { useQueryClient } from "react-query";
import { useMutationRemoveUser } from "service/users";

const LayoutUsersTableActionsRemoveUser = ({ user }) => {
  const { isOpen, onOpen, onClose } = useDisclosure();
  const toast = useToast();
  const queryClient = useQueryClient();

  const { mutate, isLoading } = useMutationRemoveUser({
    onSuccess: () => {
      queryClient.invalidateQueries("queryListUsers");

      toast({
        description: "O usuário foi removido com sucesso",
        status: "success",
        duration: 9000,
        isClosable: true,
      });

      onClose();
    },
  });

  const handleRemoveUser = () => {
    mutate(user.id);
  };

  return (
    <>
      <MenuItem onClick={onOpen} color="red">
        Remover usuário
      </MenuItem>

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
              >{`Deseja realmente remover o usuário ?`}</Text>

              <Text fontWeight={600} textAlign="center">
                Essa ação é irreversível!
              </Text>
            </Flex>
          </ModalBody>

          <ModalFooter mt="20px" justifyContent="space-between">
            <Button
              variant="ghost"
              onClick={onClose}
              disabled={isLoading}
              isLoading={isLoading}
            >
              Cancelar
            </Button>

            <Button
              variant="outline"
              background="primary"
              mr="10px"
              disabled={isLoading}
              isLoading={isLoading}
              onClick={handleRemoveUser}
            >
              Remover
            </Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </>
  );
};

export default LayoutUsersTableActionsRemoveUser;
