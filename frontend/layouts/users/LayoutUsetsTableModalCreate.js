import {
  Button,
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalFooter,
  ModalBody,
  ModalCloseButton,
  Flex,
  Text,
  useToast,
  FormControl,
  FormLabel,
  Input,
  FormErrorMessage,
} from "@chakra-ui/react";
import { useQueryClient } from "react-query";
import { useForm } from "react-hook-form";

import { useMutationCreateUser } from "service/users";

const LayoutUsetsTableModalCreate = ({ isOpen, onClose }) => {
  const toast = useToast();

  const queryClient = useQueryClient();

  const { mutate, isLoading } = useMutationCreateUser({
    onSuccess: () => {
      queryClient.invalidateQueries("queryListUsers");

      toast({
        title: "Usuário cadastrado com sucesso!",
        status: "success",
        duration: 9000,
        isClosable: true,
      });
    },
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    mutate(data);
  };

  return (
    <Modal isOpen={isOpen} onClose={onClose} size="xl">
      <ModalOverlay />

      <ModalContent>
        <form onSubmit={handleSubmit(onSubmit)}>
          <ModalHeader></ModalHeader>

          <ModalCloseButton />

          <ModalBody mt="15px">
            <Flex justify="center" direction="column">
              <Text fontSize="20px" fontWeight="bold" textAlign="center">
                Cadastro de novo usuário administrador
              </Text>

              <Flex direction="column" mt="50px">
                <FormControl isInvalid={errors.nome}>
                  <FormLabel htmlFor="nome">Nome do Usuário</FormLabel>
                  <Input
                    id="nome"
                    type="text"
                    placeholder="Ex: Vinicius Pegorini"
                    {...register("nome", {
                      required: "O nome do usuário é obrigatório",
                    })}
                  />

                  {errors.nome && (
                    <FormErrorMessage>{errors.nome.message}</FormErrorMessage>
                  )}
                </FormControl>

                <FormControl mt="30px" isInvalid={errors.email}>
                  <FormLabel htmlFor="email">Email de acesso</FormLabel>
                  <Input
                    id="email"
                    type="email"
                    placeholder="Ex: fulano@professores.utfpr.edu.br"
                    {...register("email", {
                      required: "O email de acesso é obrigatório",
                    })}
                  />

                  {errors.email && (
                    <FormErrorMessage>{errors.email.message}</FormErrorMessage>
                  )}
                </FormControl>
              </Flex>
            </Flex>
          </ModalBody>

          <ModalFooter mt="20px" justifyContent="space-between">
            <Button variant="ghost" onClick={onClose} isDisabled={isLoading}>
              Cancelar
            </Button>

            <Button
              variant="outline"
              background="primary"
              mr="10px"
              type="submit"
              isDisabled={isLoading}
            >
              Salvar Usuário
            </Button>
          </ModalFooter>
        </form>
      </ModalContent>
    </Modal>
  );
};

export default LayoutUsetsTableModalCreate;
