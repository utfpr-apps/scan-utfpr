import { Box, Flex, Text } from "@chakra-ui/react";
import Head from "next/head";
import PageTitle from "../components/PageTitle/PageTitle";

const notificationsStatus = [
  { title: "Novas Notificações", quantity: 2 },
  { title: "Casos Encerrados", quantity: 16 },
  { title: "Casos em Aberto", quantity: 5 },
  { title: "Total de Casos", quantity: 23 },
];

const notifications = [
  { name: "Felipe", date: "01/04/2022" },
  { name: "Cesar", date: "01/04/2022" },
  { name: "Maccari", date: "01/04/2022" },
  { name: "Felipe Cesar", date: "01/04/2022" },
];

export default function Home() {
  return (
    <>
      <Head>
        <link rel="preconnect" href="https://fonts.googleapis.com" />
        <link
          rel="preconnect"
          href="https://fonts.gstatic.com"
          crossOrigin={true}
        />
        <link
          href="https://fonts.googleapis.com/css2?family=Mulish:wght@300;400;600;700&display=swap"
          rel="stylesheet"
        />
        <title>SCAN UTFPR - Pato Branco</title>
      </Head>

      <Flex
        width="100%"
        px="30px"
        direction="column"
        minHeight="calc(100px - 93px)"
      >
        <PageTitle>Página Inicial</PageTitle>

        <Flex width="100%" mt="34px" justify="space-between" flexWrap="wrap">
          {notificationsStatus.map((status, index) => (
            <Flex
              key={index}
              direction="column"
              py="18px"
              px="25px"
              align="center"
              border="1px solid #dfe0eb"
              background="white"
              borderRadius="8px"
              minW="310px"
              boxShadow="rgba(149, 157, 165, 0.2) 0px 8px 24px"
              my="5px"
            >
              <Text
                color="greyText"
                fontSize="19px"
                fontWeight={700}
                letterSpacing="0.4px"
              >
                {status.title}
              </Text>

              <Text
                mt="12px"
                color="blackText"
                fontSize="40px"
                fontWeight={700}
              >
                {status.quantity}
              </Text>
            </Flex>
          ))}
        </Flex>

        <Flex
          border="1px solid #dfe0eb"
          background="white"
          borderRadius="8px"
          my="25px"
          direction="column"
          flex={1}
          p="32px"
        >
          <Text color="blackText" fontSize="19px" fontWeight="bold">
            Notificações em andamento
          </Text>

          <Text color="greyText" fontSize="12px" fontWeight={400} mt="8px">
            As notificações em andamento são aquelas em que o atestado ainda não
            atingiu o prazo final
          </Text>

          <Box mt="60px" direction="column">
            <Flex width="100%" justify="space-between" mb="10px">
              <Text color="greyText" fontSize="18px" fontWeight="semiBold">
                Aluno
              </Text>
              <Text color="greyText" fontSize="18px" fontWeight="semiBold">
                Prazo do Atestado
              </Text>
            </Flex>

            {notifications.map((notification, index) => (
              <Flex
                key={index}
                width="100%"
                justify="space-between"
                py="20px"
                borderBottom="1px solid #DFE0EB"
              >
                <Text color="blackText" fontSize="14px" fontWeight="semiBold">
                  {notification.name}
                </Text>
                <Text color="greyText" fontSize="14px" fontWeight="semiBold">
                  {notification.date}
                </Text>
              </Flex>
            ))}
          </Box>
        </Flex>
      </Flex>
    </>
  );
}
