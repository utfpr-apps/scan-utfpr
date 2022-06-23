import Image from "next/image";

import { useRouter } from "next/router";

import { useSession, signIn } from "next-auth/react";

import { Flex, Text, Button, Spinner } from "@chakra-ui/react";

import mainIllustration from "public/assets/main.svg";
import logoUTFPR from "public/assets/logo-utfpr.png";

export default function Home() {
  const { data: session, status } = useSession();

  const router = useRouter();

  if (status === "loading") {
    return (
      <Flex height="100vh" align="center" justify="center">
        <Spinner size="lg" color="yellow" />
      </Flex>
    );
  }

  if (status === "authenticated") {
    router.replace("/");
  }

  return (
    <Flex height="100vh" align="center" justify="space-between" px="15%">
      <Flex direction="column" justify="center">
        <Flex align="flex-end">
          <Text fontWeight="bold" fontSize="3rem" mr="20px">
            SCAN
          </Text>
          <Image src={logoUTFPR} alt="logo UTFPR" height="98px" width="256px" />
        </Flex>
        <Text fontWeight="bold" fontSize="1.5rem" mr="20px"></Text>

        <Button mt="50px" type="submit" background="yellow" onClick={signIn}>
          Acesse agora
        </Button>
      </Flex>

      <Flex>
        <Image src={mainIllustration} alt="logo UTFPR" />
      </Flex>
    </Flex>
  );
}
