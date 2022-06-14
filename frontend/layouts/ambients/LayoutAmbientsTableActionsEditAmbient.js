import { useQueryClient } from "react-query";

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
  FormControl,
  FormLabel,
  Input,
  FormErrorMessage,
} from "@chakra-ui/react";

import { useForm } from "react-hook-form";

import { useMutationEditAmbients } from "service/ambients";

const LayoutAmbientsTableActionsEditAmbient = ({ ambient }) => {
  const queryClient = useQueryClient();

  const { isOpen, onOpen, onClose } = useDisclosure();
  const toast = useToast();

  const { mutate, isLoading } = useMutationEditAmbients({
    onSuccess: () => {
      queryClient.invalidateQueries("queryListAmbients");

      toast({
        description: "O ambiente foi editado com sucesso",
        status: "success",
        duration: 9000,
        isClosable: true,
      });

      onClose();
    },
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    mutate({ id: ambient.id, ...data });
  };

  return (
    <>
      <MenuItem onClick={onOpen}>Editar ambiente</MenuItem>

      <Modal isOpen={isOpen} onClose={onClose} size="xl">
        <ModalOverlay />
        <ModalContent>
          <form onSubmit={handleSubmit(onSubmit)}>
            <ModalHeader></ModalHeader>

            <ModalCloseButton />

            <ModalBody mt="15px">
              <Flex justify="center" direction="column">
                <Text fontSize="20px" fontWeight="bold" textAlign="center">
                  Editar Ambiente
                </Text>

                <Flex direction="column" mt="50px">
                  <FormControl isInvalid={errors.codigoSala}>
                    <FormLabel htmlFor="codigoSala">
                      Código do Ambiente
                    </FormLabel>
                    <Input
                      id="codigoSala"
                      type="text"
                      defaultValue={ambient.codigoSala}
                      placeholder="Ex: V105"
                      {...register("codigoSala", {
                        required: "O código do ambiente é obrigatório",
                      })}
                    />

                    {errors.codigoSala && (
                      <FormErrorMessage>
                        {errors.codigoSala.message}
                      </FormErrorMessage>
                    )}
                  </FormControl>

                  <FormControl mt="30px" isInvalid={errors.tamanhoBloco}>
                    <FormLabel htmlFor="tamanhoBloco">
                      Tamanho do Bloco de Tempo (em minutos)
                    </FormLabel>
                    <Input
                      id="tamanhoBloco"
                      type="number"
                      defaultValue={ambient.tamanhoBloco}
                      placeholder="Ex: 50minutos"
                      {...register("tamanhoBloco", {
                        required:
                          "O tamanho de cada bloco de tempo é obrigatório",
                      })}
                    />

                    {errors.tamanhoBloco && (
                      <FormErrorMessage>
                        {errors.tamanhoBloco.message}
                      </FormErrorMessage>
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
                Salvar Ambiente
              </Button>
            </ModalFooter>
          </form>
        </ModalContent>
      </Modal>
    </>
  );
};

export default LayoutAmbientsTableActionsEditAmbient;
