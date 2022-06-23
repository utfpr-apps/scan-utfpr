import Container from "components/Container";
import MainLayout from "components/MainLayout";
import PageLayout from "components/PageLayout";

import LayoutUsersHeader from "./LayoutUsersHeader";
import LayoutUsersTable from "./LayoutUsersTable";

const LayoutUsers = () => (
  <MainLayout>
    <PageLayout pageTitle="Usuários">
      <Container my="25px" direction="column" flex={1} p="32px">
        <LayoutUsersHeader />

        <LayoutUsersTable />
      </Container>
    </PageLayout>
  </MainLayout>
);

export default LayoutUsers;
