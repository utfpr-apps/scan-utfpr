import Container from "components/Container";
import PageLayout from "components/PageLayout";

import LayoutUsersHeader from "./LayoutUsersHeader";
import LayoutUsersTable from "./LayoutUsersTable";

const LayoutUsers = () => (
  <PageLayout pageTitle="Notificações">
    <Container my="25px" direction="column" flex={1} p="32px">
      <LayoutUsersHeader />

      <LayoutUsersTable />
    </Container>
  </PageLayout>
);

export default LayoutUsers;
