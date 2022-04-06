import { useToast } from "@chakra-ui/react";

import { GoogleLogin } from "react-google-login";

import { useMutationLogin } from "../service/oAuthData";

export default function Home() {
  const toast = useToast();

  const { mutate, isLoading } = useMutationLogin({
    onSuccess: () => {
      toast({
        title: "deu boa, foi pro backend",
        status: "success",
        duration: 9000,
        isClosable: true,
      });
    },
  });

  const responseGoogle = ({ tokenObj }) => {
    const { idpId, access_token } = tokenObj;

    mutate({
      provider: idpId,
      idToken: access_token,
      tipoUsuario: 1,
      registroAcademico: "a1272314",
    });
  };

  return (
    <div>
      <GoogleLogin
        clientId={process.env.NEXT_PUBLIC_GOOGLE_CLIENT_ID}
        buttonText="Login"
        onSuccess={responseGoogle}
        onFailure={responseGoogle}
        cookiePolicy={"single_host_origin"}
        isSignedIn={true}
      />

      {isLoading ? <div>ta logando, perae!</div> : null}
    </div>
  );
}
