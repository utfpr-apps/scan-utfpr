import Container from "components/Container";
import MainLayout from "components/MainLayout";
import PageLayout from "components/PageLayout";

import LayoutAmbientsHeader from "./LayoutAmbientsHeader";
import LayoutAmbientsTable from "./LayoutAmbientsTable";

const LayoutAmbients = () => (
  <MainLayout>
    <PageLayout pageTitle="Salas e Ambientes">
      <Container my="25px" direction="column" flex={1} p="32px">
        <LayoutAmbientsHeader />

        <LayoutAmbientsTable />
      </Container>
    </PageLayout>
  </MainLayout>
);

export default LayoutAmbients;
