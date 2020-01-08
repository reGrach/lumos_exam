<template>
  <v-card :color="colorQuestion" dark>
    <div>
      <v-alert v-model="alert" dense outlined type="error" dismissible>
        <strong>{{error}}</strong>
      </v-alert>
    </div>

    <v-badge color="green" :content="number" left :offset-x="15" :offset-y="15">
      <v-card-text style="padding-bottom:0; padding-top:6px" class="text-justify" v-html="quest.text"></v-card-text>
    </v-badge>

    <v-card-actions style="padding-top:0">
      <v-btn icon @click="updateStatusQuest(quest.id, quest.isWritten, statusEnum.isWritten)">
        <v-icon :color="getWritten">mdi-pencil</v-icon>
      </v-btn>

      <v-btn icon @click="updateStatusQuest(quest.id, quest.isLearned, statusEnum.isLearned)">
        <v-icon v-if="getLearned" color="green">mdi-emoticon-outline</v-icon>
        <v-icon v-else color="red">mdi-emoticon-frown-outline</v-icon>
      </v-btn>

      <v-spacer></v-spacer>

      <v-btn icon @click="updateStatusQuest(quest.id, quest.isDeferred, statusEnum.isDeferred)">
        <v-icon :color="getDeferred">mdi-update</v-icon>
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
import { updateStatus } from "@/axios";
export default {
  props: {
    quest: Object,
    number: Number
  },

  data: () => ({
    alert: false,
    error: null,
    colorQuestion: "#006064",
    statusEnum: Object.freeze({
      isWritten: 1,
      isLearned: 2,
      isDeferred: 3
    })
  }),

  computed: {
    getLearned() {
      return this.quest.isLearned ? true : false;
    },
    getWritten() {
      return this.quest.isWritten ? "green" : "red";
    },
    getDeferred() {
      return this.quest.isDeferred ? "yellow" : "white";
    }
  },

  methods: {
    updateStatusQuest(id, val, status) {
      updateStatus(id, !val, status)
        .then(() => {
          switch (status) {
            case this.statusEnum.isWritten:
              this.quest.isWritten = !this.quest.isWritten;
              break;
            case this.statusEnum.isLearned:
              this.quest.isLearned = !this.quest.isLearned;
              break;
            case this.statusEnum.isDeferred:
              this.quest.isDeferred = !this.quest.isDeferred;
              break;
          }
        })
        .catch(() => {
          this.error = "Не получилось...( Обратись к Гере.";
        });
    }
  }
};
</script>